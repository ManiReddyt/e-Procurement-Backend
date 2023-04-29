using AutoMapper;
using EProcurement.Applications.DTO;
using EProcurement.Domain.Models;
using EProcurement.Infrastructure.DataBase;
using EProcurment.Services.Contracts;
using Dapper;
using System.Data;

namespace EProcurment.Services.Implementations
{
    public class BuyerServices : IBuyerServices
    {
        private IDbConnection dbConnection;
        private readonly IMapper mapper;
        private readonly DapperDbContext dapperContext;
        public BuyerServices(IMapper mapper, DapperDbContext dapperContext)
        {
            this.dapperContext = dapperContext;
            this.dbConnection = this.dapperContext.CreateConnection();
            this.mapper = mapper;
        }
        public void BuyerRegisterRequest(BuyerRegisterRequestDTO registerRequest)
        {
            BuyerRegistrationRequest buyerRequest = this.mapper.Map<BuyerRegistrationRequest>(registerRequest);
            var query = "INSERT INTO BuyerRegistrationRequest(Name,Designation,Email,Password) VALUES (@Name,@Designation,@Email,@Password)";
            this.dbConnection.Query(query, buyerRequest);
        }

        public void BidderRegisterRequest(BidderRegisterRequestDTO registerRequest)
        {
            BidderRegistrationRequest buyerRequest = this.mapper.Map<BidderRegistrationRequest>(registerRequest);
            var query = "INSERT INTO BuyerRegistrationRequest(Name,ComanyName,Experience,SuccessfulTenders,Email,Password) VALUES (@Name,@ComanyName,@Experience,@SuccessfulTenders,@Email,@Password)";
            this.dbConnection.Query(query, buyerRequest);
        }

        public void AddTender(TenderDTO tenderDTO)
        {
            Tender tender = this.mapper.Map<Tender>(tenderDTO);
            tender.CreatedOn = DateTime.UtcNow;
            string name = tenderDTO.SubCategory;
            var query = "SELECT Id FROM SubCategory WHERE Name = @name";
            SubCategory categoryDetails=this.dbConnection.QueryFirstOrDefault<SubCategory>(query, new {name});
            tender.CategoryId = categoryDetails.CategoryId;
            tender.SubCategoryId = categoryDetails.Id;
            query = "INSERT INTO BuyerRegistrationRequest(Title,Description,CreatedOn,ExpiresOn,Budget,CategoryId,SubCategoryId,CreatedBy) VALUES (@Title,@Description,@CreatedOn,@ExpiresOn,@Budget,@CategoryId,@SubCategoryId,@CreatedBy)";
            this.dbConnection.Execute(query, tender);
        }

        public void ApproveTender(Guid tenderId,Guid userId)
        {
            var query = "INSERT INTO TenderApprovals(TenderId,UserId) VALUES (@tenderId,@userId)";
            this.dbConnection.Execute(query, new { tenderId, userId });
        }

        public List<GetTendersDTO> GetTenders()
        {
            var query = "SELECT Id,Title,ExpiresOn FROM Tender";
            return this.dbConnection.Query<GetTendersDTO>(query).ToList();      
        }
        public TenderAnalyticsDTO GetTenderById(Guid id)
        {
            var query = "SELECT Id,Title,Description FROM Tender WHERE Id=@id";
            TenderAnalyticsDTO tenderAnalytics = this.dbConnection.QueryFirstOrDefault<TenderAnalyticsDTO>(query, new { id });
            
            query = "SELECT * FROM BidAndPrediction WHERE Id=@id ORDERBY Rating";
            List<BidAndPrediction> tenderBids = this.dbConnection.Query<BidAndPrediction>(query, new { id }).ToList();
            for(int i = 0; i<10 ;i++)
            {
                Guid bidderId = tenderBids[i].Id;
                query = "SELECT * FROM User WHERE Id=@bidderId";
                User user = this.dbConnection.QueryFirstOrDefault<User>(query, new { bidderId });

                RecommendationsAndBidsDTO recomendation = this.mapper.Map<RecommendationsAndBidsDTO>(tenderBids[i]);
                recomendation.Name = user.UserName;
                recomendation.Experience = user.Experience;
                tenderAnalytics.Recommendations.Add(recomendation);
            }

            for (int i = 10; i < tenderBids.Count(); i++)
            {
                Guid bidderId = tenderBids[i].Id;
                query = "SELECT * FROM User WHERE Id=@bidderId";
                User user = this.dbConnection.QueryFirstOrDefault<User>(query, new { bidderId });

                RecommendationsAndBidsDTO recomendation = this.mapper.Map<RecommendationsAndBidsDTO>(tenderBids[i]);
                recomendation.Name = user.UserName;
                recomendation.Experience = user.Experience;
                tenderAnalytics.Bids.Add(recomendation);
            }
            return tenderAnalytics;
        }
        public TenderDTO GetTenderDetails(Guid id)
        {
            var query = "SELECT * FROM Tender WHERE Id=@id";
            Tender tender = this.dbConnection.QueryFirstOrDefault<Tender>(query, new { id });
            TenderDTO tenderDetails = this.mapper.Map<TenderDTO>(tender);

            id = tender.CategoryId;
            query = "SELECT Name FROM Category WHERE Id = @id";
            Category categoryDetails = this.dbConnection.QueryFirstOrDefault<Category>(query, new { id });
            tenderDetails.Category = categoryDetails.Name;

            id = tender.SubCategoryId;
            query = "SELECT Name FROM SubCategory WHERE Id = @id";
            SubCategory subCategoryDetails = this.dbConnection.QueryFirstOrDefault<SubCategory>(query, new { id });
            tenderDetails.SubCategory = categoryDetails.Name;

            return tenderDetails;
        }
    }
}
