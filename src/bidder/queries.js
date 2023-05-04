const getActiveTenders = "select * from tender where expireson > $1";
const addBid =
  "insert into bids (tenderId, description, bidcreatedOn, quotingPrice, deliveryOn, deliveryTerms, warrenty, warrentyTerms, bidderId, rating) values ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10)";
const getUserBids =
  "select * from tender inner join bids on tender.id = bids.tenderid where bids.bidderid = $1";
const userDetails = 'select experience,successfulbids from "User" where id=$1';
const tenderDetails = "select subcategoryid,budget from tender where id=$1";
const subCategoryName = "select subcategoryname from subcategory where id=$1";
const checkIfExists =
  "select * from bids where tenderid = $1 and bidderid = $2";

module.exports = {
  getActiveTenders,
  getUserBids,
  addBid,
  userDetails,
  tenderDetails,
  subCategoryName,
  checkIfExists,
};
