const pool = require("../../dbconnection");
const queries = require("./queries");

const getUsers = (req, res) => {
  pool.query(queries.getUsers, (error, results) => {
    if (error) {
      res.status(404).send(error);
    } else {
      res.status(200).json(results.rows);
    }
  });
};

const getUsers = (req, res) => {
  pool.query(queries.getUsers, (error, results) => {
    if (error) {
      res.status(404).send(error);
    } else {
      res.status(200).json(results.rows);
    }
  });
};

const getUserNameById = (req, res) => {
  const id = req.params.id;
  pool.query(queries.getUserNameById, [id], (error, results) => {
    if (error) {
      res.status(404).send(error);
    } else {
      res.status(200).json(results.rows);
    }
  });
};

const addRegisterRequest = (req, res) => {
  const {
    userName,
    email,
    password,
    designationOrCompanyName,
    experience,
    successfulBids,
    userType,
  } = req.body;

  pool.query(
    queries.addRegisterRequest,
    [
      userName,
      email,
      password,
      designationOrCompanyName,
      experience,
      successfulBids,
      userType,
    ],
    (error, results) => {
      if (error) {
        res.status(404).send(error);
      } else {
        res.status(200).send("Requested admin to register");
      }
    }
  );
};

const processRegistration = (req, res) => {
  const { id, status } = req.body;

  pool.query(queries.processRegistration, [status, id], (error, results) => {
    if (error) {
      res.status(404).send(error);
    } else {
      res.status(200).send("registration request processed");
    }
  });
};

const login = (req, res) => {
  const { username, password, usertype } = req.body;

  pool.query(
    queries.login,
    [username, password, usertype],
    (error, results) => {
      if (error) {
        console.log(error);
        res.status(404).send(error);
      } else {
        res.status(400).send(results.rows);
      }
    }
  );
};

module.exports = {
  getUserNameById,
  addRegisterRequest,
  processRegistration,
  getUsers,
  login,
};
