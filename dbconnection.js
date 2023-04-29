const { password } = require("pg/lib/defaults");

const Pool = require("pg").Pool;
const pool = new Pool({
  host: "localhost",
  user: "postgres",
  port: 5432,
  password: "9390348710",
  database: "e-procurement",
});

module.exports = pool;
