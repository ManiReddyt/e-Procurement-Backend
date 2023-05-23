const axios = require("axios");
const pool = require("../../dbconnection");
const queries = require("./queries");
const subcat = require("../../data/subcategories");

const getActiveTenders = (req, res) => {
  const date = new Date();
  pool.query(queries.getActiveTenders, [date.toJSON()], (error, results) => {
    if (error) {
      res.status(404).send(error);
    } else {
      res.status(200).json(results.rows);
    }
  });
};

const getUserBids = (req, res) => {
  const id = req.params.id;
  pool.query(queries.getUserBids, [id], (error, results) => {
    if (error) {
      res.status(404).send(error);
    } else {
      res.status(200).json(results.rows);
    }
  });
};

// const test = async (req,res) => {

// }

const addBid = async (req, res) => {
  const {
    tenderId,
    description,
    quotingPrice,
    deliveryOn,
    deliveryTerms,
    warrenty,
    warrentyTerms,
    paymentTerms,
    bidderId,
  } = req.body;
  // checking if bidder already exists
  const checkIfExists = await pool.query(queries.checkIfExists, [
    tenderId,
    bidderId,
  ]);
  if (checkIfExists.rows.length > 0) {
    res.status(400).send("You can only bid once for a tender");
    return;
  }

  // connect and call for ml model
  var bidRating = 0;
  const userDetails = await pool.query(queries.userDetails, [bidderId]);
  const tenderDetails = await pool.query(queries.tenderDetails, [tenderId]);
  const subcategory = await pool.query(queries.subCategoryName, [
    tenderDetails.rows[0]["subcategoryid"],
  ]);
  // try {
  //   const response = await axios.post("http://127.0.0.1:5000/api/predict", {
  //     experience: userDetails.rows[0]["experience"],
  //     successfulTenders: userDetails.rows[0]["successfulbids"],
  //     subCategory: subcat.subcategory[subcategory.rows[0]["subcategoryname"]],
  //     budget: tenderDetails.rows[0]["budget"],
  //     quotigPrice: 50000,
  //   });
  //   bidRating = response.data["prediction"];
  // } catch (error) {
  //   console.log(error);
  //   res.status(500).send("Error in connecting to ML model");
  // }

  //adding bid to database
  const bidcreatedOn = new Date();
  await pool.query(
    queries.addBid,
    [
      tenderId,
      description,
      bidcreatedOn,
      quotingPrice,
      deliveryOn,
      deliveryTerms,
      warrenty,
      warrentyTerms,
      paymentTerms,
      bidderId,
      bidRating,
    ],
    (error, results) => {
      if (error) {
        console.log("error1", error);
        res.status(404).send(error);
      } else {
        res.status(200).send("Successfully Bidded");
      }
    }
  );
};

module.exports = {
  getActiveTenders,
  getUserBids,
  addBid,
  // test,
};
