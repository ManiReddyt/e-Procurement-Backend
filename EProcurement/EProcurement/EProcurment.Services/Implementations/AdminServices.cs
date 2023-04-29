using AutoMapper;
using Dapper;
using EProcurement.Applications.DTO;
using EProcurement.Domain.Models;
using EProcurement.Infrastructure.DataBase;
using EProcurment.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EProcurment.Services.Implementations
{
    public class AdminServices:IAdminServices
    {
        private IDbConnection dbConnection;
        private readonly IMapper mapper;
        private readonly DapperDbContext dapperContext;
        public AdminServices(IMapper mapper, DapperDbContext dapperContext)
        {
            this.dapperContext = dapperContext;
            this.dbConnection = this.dapperContext.CreateConnection();
            this.mapper = mapper;
        }

        public List<BuyerRegisterRequestDTO> GetBuyerRegisterRequests()
        {
            var query = "SELECT * FROM BuyerRegistrationRequest WHERE IsApproved=null";
            List<BuyerRegistrationRequest> registerRquests = this.dbConnection.Query<BuyerRegistrationRequest>(query).ToList();
            List<BuyerRegisterRequestDTO> requests = new List<BuyerRegisterRequestDTO>();
            foreach(BuyerRegistrationRequest registration in registerRquests)
            {
                requests.Add(this.mapper.Map<BuyerRegisterRequestDTO>(registration));
            }
            return requests;
        }

        public List<BidderRegisterRequestDTO> GetBidderRegisterRequests()
        {
            var query = "SELECT * FROM BidderRegistrationRequest WHERE IsApproved=null";
            List<BidderRegistrationRequest> registerRquests = this.dbConnection.Query<BidderRegistrationRequest>(query).ToList();
            List<BidderRegisterRequestDTO> requests = new List<BidderRegisterRequestDTO>();
            foreach (BidderRegistrationRequest registration in registerRquests)
            {
                requests.Add(this.mapper.Map<BidderRegisterRequestDTO>(registration));
            }
            return requests;
        }

        public void AcceptBidder(Guid id)
        {
            var query = "Update BidderRegistrationRequest SET IsApproved=1 WHERE Id=@id";
            this.dbConnection.Query(query, new { id });

            query = "SELECT * FROM BidderRegistrationRequest WHERE Id=id";
            BidderRegistrationRequest bidder = this.dbConnection.QueryFirstOrDefault<BidderRegistrationRequest>(query, new { id });

            string name = bidder.Name;
            int userType = 1;
            int experience = bidder.Experience;
            query = "INSERT INTO [User](UserName,UserType,Experience) VALUES (@name,@userType,@experience)";
            this.dbConnection.Query(query, new { name, userType, experience });
        }

        public void RejectBidder(Guid id)
        {
            var query = "Update BidderRegistrationRequest SET IsApproved=0 WHERE Id=@id";
            this.dbConnection.Query(query, new {id});
        }

        public void AcceptBuyer(Guid id)
        {
            var query = "Update BuyerRegistrationRequest SET IsApproved=1 WHERE Id=@id";
            this.dbConnection.Query(query, new { id });

            query = "SELECT * FROM BuyerRegistrationRequest WHERE Id=id";
            BuyerRegistrationRequest buyer = this.dbConnection.QueryFirstOrDefault<BuyerRegistrationRequest>(query, new { id });

            string name = buyer.Name;
            int userType = 0;
            int experience = 0;
            query = "INSERT INTO [User](UserName,UserType,Experience) VALUES (@name,@userType,@experience)";
            this.dbConnection.Query(query, new { name, userType, experience });
        }

        public void RejectBuyer(Guid id)
        {
            var query = "Update BuyerRegistrationRequest SET IsApproved=0 WHERE Id=@id";
            this.dbConnection.Query(query, new { id });
        }
    }
}
