const { password } = require('pg/lib/defaults')

const Pool = require('pg').Pool
const pool = new Pool({
    user: "postgres",
    host: "localhost",
    database: "EProcurement",
    password: "Nithin@2001",
    port: 5432,
});

module.exports = pool;