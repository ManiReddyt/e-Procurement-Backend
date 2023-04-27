const events = require('events');
const express = require('express')
const buyerRoutes = require('./src/buyer/routes');
const bidderRoutes = require('./src/bidder/routes');
const adminRoutes = require('./src/admin/routes');

const app = express()
const port = 3000

const emitter = new events.EventEmitter()
emitter.setMaxListeners(100)

app.use(express.json());
app.use('/api/buyer',buyerRoutes);
app.use('/api/bidder',bidderRoutes);
app.use('/api/admin',adminRoutes);

app.listen(port)