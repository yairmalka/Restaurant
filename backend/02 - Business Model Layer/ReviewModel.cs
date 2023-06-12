using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }

        public int? CustomerId { get; set; }

        public int? OrderId { get; set; }

        public DateTime? ReviewDate { get; set; }

        public int? ReviewRating { get; set; }

        public string? ReviewData { get; set; }

        public ReviewModel(Review review)
        {
            this.ReviewId = review.ReviewId;
            this.CustomerId = review.CustomerId;
            this.OrderId = review.OrderId;
            this.ReviewDate = review.ReviewDate;
            this.ReviewRating = review.ReviewRating;
            this.ReviewData = review.ReviewData;
        }

        public ReviewModel() { } 
    }
}
