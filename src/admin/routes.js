const {Router} = require('express');
const controller = require('./controller')

const router = Router();

router.get('/users',controller.getUsers);
router.get('/user/:id/username',controller.getUserNameById);
router.post('/registerrequest',controller.addRegisterRequest);
router.post('/processRegistration',controller.processRegistration);


module.exports = router;