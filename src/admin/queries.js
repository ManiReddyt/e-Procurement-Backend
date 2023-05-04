const getUsers = 'select * from "User"';
const getUserNameById = 'select username from "User" where id = $1';
const addRegisterRequest =
  'insert into "User" (userName,email,password,designationOrCompanyName,experience,successfulBids,userType) values ($1,$2,$3,$4,$5,$6,$7)';
const processRegistration = 'update "User" set status = $1 where id = $2';
const login =
  'select status from "User" where username = $1 and password = $2 and usertype = $3';

module.exports = {
  getUserNameById,
  addRegisterRequest,
  processRegistration,
  getUsers,
  login,
};
