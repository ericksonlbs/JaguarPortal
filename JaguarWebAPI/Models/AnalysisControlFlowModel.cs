using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JaguarWebAPI.Models
{
    public class AnalysisControlFlowNewModel
    {
        public string ProjectID { get; set; }
        public List<ClassAnalyze> Classes { get; set; }
        public string Heuristic{get;set;}
        public string TotalTests{get;set;}
        public string FailedTests{get;set;}        

    }
    public class AnalysisControlFlowModel: AnalysisControlFlowNewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }        
        public DateTime CreatedDate { get; set; }

    }

    public class ClassAnalyze
    {
        public string FullName{get;set;}
        public string Path{get;set;}
        public string Code{get;set;}
        public List<LineAnalyze> Lines{get;set;}

    }

    public class LineAnalyze
    {
        public string Method{get;set;}
        public int NumberLine{get;set;}
        public int CEF{get;set;}
        public int CEP{get;set;}
        public int CNF{get;set;}
        public int CNP{get;set;}
        public double SuspiciousValue{get;set;}
    }

}