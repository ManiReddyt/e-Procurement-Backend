const pool = require('../../dbconnection')
const queries = require('./queries')

const getActiveTenders = (req,res) => {
    const date = new Date();
    pool.query(queries.getActiveTenders, [date.toJSON()] ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).json(results.rows);
        }
    });
}

const getUserBids = (req,res) => {
    const id = req.params.id;
    pool.query(queries.getUserBids, [id], (error,results) => {
        if(error){
            res.status(404).send(error);
         }
         else{
             res.status(200).json(results.rows);
         }
    })
}


const addBid = (req,res) => {
    const {tenderId, description, quotingPrice, deliveryOn, deliveryTerms, warrenty, warrentyTerms, paymentTerms, bidderId} = req.body;
    // call for ml model
    const bidRating = 10;

    const createdOn = new Date();
    pool.query(queries.addBid, [tenderId, description, createdOn, quotingPrice, deliveryOn, deliveryTerms, warrenty, warrentyTerms, paymentTerms, bidderId, bidRating] ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).send('Successfully Bidded');
        }
    });
}

module.exports = {
    getActiveTenders,
    getUserBids,
    addBid,
}