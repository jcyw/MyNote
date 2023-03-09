let apiKey = '517c0ca25130c469a9a8388f511af61f';
let city = 'chengdu';
let url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}`;
const request = require('request');
const fetch = require("node-fetch")

// fetch(url).then(response => {
//     if (response.ok) {
//         return response.json();
//     } else {
//         // throw new Error('Network response was not ok.');
//     }
// }).then(data => {
//     console.log(data);
// }).catch(error => {
//     console.error('There has been a problem with your fetch operation:', error);
// });

const https = require('https');

// https.get(url, (response) => {
//   let data = '';

//   // A chunk of data has been received.
//   response.on('data', (chunk) => {
//     data += chunk;
//   });

//   // The whole response has been received. Print out the result.
//   response.on('end', () => {
//     console.log(JSON.parse(data));
//   });

// }).on("error", (error) => {
//   console.error(error.message);
// });


request({
  url: 'https://ipinfo.io/json',
  json: true
}, (error, response, body) => {
  if (error) {
    console.log(error);
  } else {
    const location = body.loc.split(',');
    const latitude = location[0];
    const longitude = location[1];
    console.log(latitude);
    console.log(longitude);
  }
});
