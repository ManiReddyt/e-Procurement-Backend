const getActiveTenders = "select * from tender where expireson > $1";
const addBid =
  "insert into Bids (tenderId, description, bidcreatedon, quotingPrice, deliveryOn, deliveryTerms, warrenty, warrentyTerms, paymentTerms, bidderId, rating) values ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11)";
const getUserBids =
  "select * from tender inner join bids on tender.id = bids.tenderid where bids.bidderid = $1";

module.exports = {
  getActiveTenders,
  getUserBids,
  addBid,
};
