﻿using System;
using System.Diagnostics;

namespace KozzionGraphics.Image.Raster
{
    public class Raster3DIntegerSub : 
            ARasterInteger,
            IRaster3DInteger
    {
        private IRaster3DInteger parent;
        private int offset_x;
        private int offset_y;
        private int offset_z;

        public int Size0 { get { return size[0]; } } 
        public int Size1 { get { return size[1]; } }
        public int Size2 { get { return size[2]; } }

        public Raster3DIntegerSub(IRaster3DInteger parent, int offset_x, int size_x, int offset_y, int size_y, int offset_z, int size_z)
            : base(new int[] { size_x, size_y, size_z })
        {        
            this.parent = parent;
            this.offset_x = offset_x;
            this.offset_y = offset_y;
            this.offset_z = offset_z;
        } 

        public bool ContainsCoordinates(int coordinate_x, int coordinate_y, int coordinate_z)
        {
            if ((0 <= coordinate_x) && (0 <= coordinate_y) && (0 <= coordinate_z) && (coordinate_x < size[0]) && (coordinate_y < size[1]) && (coordinate_z < size[2]))
            {
                return true;
            }
            return false;
        }

        public int GetElementIndex(int coordinate_x, int coordinate_y, int coordinate_z)
        {
            return parent.GetElementIndex(coordinate_x - offset_x, coordinate_y - offset_y, coordinate_z - offset_z);
        }

        public IRaster3DInteger GetSubRaster(int offset_x, int size_x, int offset_y, int size_y, int offset_z, int size_z)
        {
            if ((offset_x < 0) || (Size0 < offset_x + size_x))
            {
                throw new Exception("out of bounds in x");
            }

            if ((offset_y < 0) || (Size1 < offset_y + size_y))
            {
                throw new Exception("out of bounds in y");
            }

            if ((offset_z < 0) || (Size2 < offset_z + size_z))
            {
                throw new Exception("out of bounds in z");
            }
            return new Raster3DIntegerSub(this, offset_x, size_x, offset_y, size_y, offset_z, size_z);
        }

        public override int GetElementIndex(int[] coordinates)
        {
            return GetElementIndex(coordinates[0], coordinates[1], coordinates[2]);
        }

        public override void GetElementCoordinatesRBA(int element_index, int[] coordinates)
        {
            coordinates[0] = element_index % size[0];
            coordinates[1] = (element_index % (size[0] * size[1])) / size[0];
            coordinates[2] = element_index / (size[0] * size[1]);
        }

        public override void GetNeigbourhoodElementIndexesRBA(int[] coordinates, int[] neigbourhood_size, int[] neigbourhood_indexes)
        {
            Debug.Assert(coordinates.Length == 3);
            Debug.Assert(neigbourhood_size.Length == 3);
            Debug.Assert(neigbourhood_indexes.Length == ((neigbourhood_size[0] * 2) + 1) * ((neigbourhood_size[1] * 2) + 1) * ((neigbourhood_size[2] * 2) + 1));
            int element_index_index = 0;
            for (int coordinate_z = coordinates[2] - neigbourhood_size[2]; coordinate_z < coordinates[2] + neigbourhood_size[2] + 1; coordinate_z++)
            {
                for (int coordinate_y = coordinates[1] - neigbourhood_size[1]; coordinate_y < coordinates[1] + neigbourhood_size[1] + 1; coordinate_y++)
                {
                    for (int coordinate_x = coordinates[0] - neigbourhood_size[0]; coordinate_x < coordinates[0] + neigbourhood_size[0] + 1; coordinate_x++)
                    {
                        int element_index = GetElementIndex(coordinate_x, coordinate_y, coordinate_z);
                        if (ContainsElement(element_index))
                        {
                            neigbourhood_indexes[element_index_index] = element_index;
                        }
                        else
                        {
                            neigbourhood_indexes[element_index_index] = -1;
                        }

                        element_index_index++;
                    }
                }
            }
        }
    }
}
