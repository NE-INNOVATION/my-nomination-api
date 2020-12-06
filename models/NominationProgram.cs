﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace my_nomination_api.models
{
    public class NominationProgram
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("programId")]
        public string ProgramId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("nominationStartDate")]
        public DateTime NominationStartDate { get; set; }

        [BsonElement("nominationEndDate")]
        public DateTime NominationEndDate { get; set; }

        [BsonElement("courseAgenda")]
        public string CourseAgenda { get; set; }

        [BsonElement("banner")]
        public byte[] Banner { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }
    }
}
