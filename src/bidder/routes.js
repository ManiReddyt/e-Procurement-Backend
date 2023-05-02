const {Router} = require("express");
const controller = require("./controller");

const router = Router();

router.get('/activetenders',controller.getActiveTenders);
router.get('/:id/bids',controller.getUserBids);
router.post('/bid',controller.addBid);
router.post('/test',controller.test);

module.exports = router;