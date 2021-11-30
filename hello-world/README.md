Démarrer le serveur : `npm run dev`

//http://127.0.0.1:3333/navigate?url=p/activities&action=click&x=150&y=180

// // await page.setExtraHTTPHeaders({
// //   'Accept' : 'application/json',
// //   'Content-Type' : 'application/json',
// //   'User-Agent': 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36',
// //   'Authorization': 'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyaWQiOjM5NywidXNlcm5hbWUiOiJ0ZGFuaWVsIiwiaW5zdGFuY2VpZCI6MzB9.N2MwNTg0MTc5NzZiNTU1NGMxYzFjZGYwMTA3NTBiNjlmMzAxYzU5OGIxZDViYTRhYjEzYjEwNTc3MmNlNDIyYQ'
// // });
// await page.setRequestInterception(true);
// page.on('request', (request) => {
//   // if (!request.isNavigationRequest()) {
//   //   request.continue();
//   //   return;
//   // }
//   const headers = request.headers();
//   headers['Accept'] = 'text/html';
//   headers['Content-Type'] = 'text/html';
//   headers['Referer']= 'http://localhost:8030/p/activities';
//   headers['User-Agent'] = 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.114 Safari/537.36';
//   headers['Authorization'] = 'Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyaWQiOjM5NywidXNlcm5hbWUiOiJ0ZGFuaWVsIiwiaW5zdGFuY2VpZCI6MzB9.N2MwNTg0MTc5NzZiNTU1NGMxYzFjZGYwMTA3NTBiNjlmMzAxYzU5OGIxZDViYTRhYjEzYjEwNTc3MmNlNDIyYQ';
//   request.continue({ headers });
// });