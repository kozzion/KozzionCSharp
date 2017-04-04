﻿using KozzionMachineLearning.DataSet;
using KozzionMachineLearning.Model;
using KozzionMathematics.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KozzionMachineLearning.Model
{
    public abstract class AModelLikelihood<DomainType, LabelType, LikelihoodType> : 
        AModelDiscrete<DomainType, LabelType>, 
        IModelLikelihood<DomainType, LabelType, LikelihoodType>
        where LikelihoodType : IComparable<LikelihoodType>
    {
        public AModelLikelihood(IDataContext data_context, string model_type)
            : base(data_context, model_type)
        { 

        }

        public override LabelType GetLabel(DomainType [] instance_features)
        {
            throw new NotImplementedException();
            //return DataContext.GetLabelValue(ToolsMathCollection.MaxIndex(GetLikelihoods(instance_features)));
        }

        public abstract LikelihoodType[] GetLikelihoods(DomainType [] instance_features);


    
    }
}
