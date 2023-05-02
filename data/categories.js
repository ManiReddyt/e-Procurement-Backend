categories = ['Goods Procurement',
'Intellectual Property (IP)',
'Public-Private Partnership',
'Green Procurement',
'Disaster Management Procurement',
'Research and Development (R&D) Procurement',
'Defence Procurement',
'Works Procurement',
'Services Procurement',
'International Procurement',
'Small and Medium Enterprises (SMEs) Procurement',
'Disinvestment',
'Social Procurement',
'Research and Development (R&D)',
'Intellectual Property (IP) Procurement']

const category ={}
categories.forEach((cat,index) => {
   category[cat] = index;
});

module.exports = {
    category
 }