const {Router} = require('express');
const controller = require('./controller')

const router = Router();

router.get('/:id/tenders',controller.getTendersForUser);
router.get('/categories',controller.getCategories);
router.get('/category/:id/subcategories',controller.getSubCatByCatId);
router.get('/tender/:id/bids',controller.getBidsByTenderId)
router.post('/tender',controller.addTender);
router.post('/tender/:tenderid/winner/:winnerid',controller.declareWinner)

module.exports = router;