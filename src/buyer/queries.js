const getTendersByUserId = 'select * from tender where createdby = $1';
const getCategories = 'select * from category';
const getSubCatByCatId = 'select id,subcategoryname from subcategory where categoryid = $1';
const getBidsByTenderId = 'select * from Bids where tenderid = $1';
const addTender = 'insert into Tender (Title,Description,CreatedOn,ExpiresOn,Budget,CategoryId,SubCategoryId,CreatedBy) values ($1,$2,$3,$4,$5,$6,$7,$8)';
const declareWinner = "update tender set winner = $1 where id = $2";

module.exports = {
    getTendersByUserId,
    getCategories,
    getSubCatByCatId,
    addTender,
    getBidsByTenderId,
    declareWinner
}