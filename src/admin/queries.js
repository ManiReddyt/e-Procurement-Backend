const getUserNameById = 'select username from "User" where id = $1';
const addRegisterRequest = 'insert into "User" (userName,email,password,designationOrCompanyName,experience,successfulBids,userType) values ($1,$2,$3,$4,$5,$6,$7)';
const processRegistration = 'update "User" set status = $1 where id = $2';

module.exports = {
    getUserNameById,
    addRegisterRequest,
    processRegistration,
}