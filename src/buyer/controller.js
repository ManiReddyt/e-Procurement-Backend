const pool = require('../../dbconnection')
const queries = require('./queries')

const getTendersForUser = (req,res) => {
    const id = req.params.id;
    pool.query(queries.getTendersByUserId, [id] ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).json(results.rows);
        }
    });
}

const getCategories = (req,res) => {
    pool.query(queries.getCategories ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).json(results.rows);
        }
    });
}

const getSubCatByCatId = (req,res) => {
    const id = req.params.id;
    pool.query(queries.getSubCatByCatId, [id] ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).json(results.rows);
        }
    });
}

const getBidsByTenderId = (req,res) => {
    const id = req.params.id;
    pool.query(queries.getBidsByTenderId, [id] ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).json(results.rows);
        }
    });
}

const addTender = (req,res) => {
    const {Title,Description,ExpiresOn,Budget,CategoryId,SubCategoryId,CreatedBy} = req.body;  
    const createdOn = new Date().toJSON();

    // if(ExpiresOn < createdOn.toJSON()){
    //     res.status(400).send('invalid expiry timestamp');
    //     return;
    // }
    

    pool.query(queries.addTender, [Title,Description,createdOn,ExpiresOn,Budget,CategoryId,SubCategoryId,CreatedBy] ,(error, results) =>{
        if(error){
           res.status(404).send(error);
        }
        else{
            res.status(200).send('Tender added');
        }
    });
}


module.exports = {
    getTendersForUser,
    getCategories,
    getSubCatByCatId,
    addTender,
    getBidsByTenderId,
}