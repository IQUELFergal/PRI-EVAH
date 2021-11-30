import Route from '@ioc:Adonis/Core/Route';
import puppeteer from 'puppeteer';
import fs from 'fs';

declare const window: any;
declare const document: any;

const BASE_URL = 'https://sequoia-labo.emanrisk.lan';

function formatUrl(rawUrl: string) {
  let outLink = rawUrl.replace(BASE_URL, '');
  if (0 === outLink.indexOf('/')) {
    outLink = outLink.slice(1);
  }

  return outLink;
}

Route.get('/', async () => {
  return { hello: 'world' };
});

Route.get('/navigate', async (ctx) => {
  const queryElements = ctx.request.all();
  const targetUrl = formatUrl(queryElements.url);

  const browser = await puppeteer.launch({
    ignoreHTTPSErrors: true,
  });
  const page = await browser.newPage();
  await page.setViewport({ width: 1920, height: 1080 });
  await page.goto(BASE_URL);
  await page.evaluate(() => {
    window.sessionStorage.setItem(
      '_token',
      'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyaWQiOjM5NywidXNlcm5hbWUiOiJ0ZGFuaWVsIiwiaW5zdGFuY2VpZCI6MzB9.N2MwNTg0MTc5NzZiNTU1NGMxYzFjZGYwMTA3NTBiNjlmMzAxYzU5OGIxZDViYTRhYjEzYjEwNTc3MmNlNDIyYQ'
    );
    window.sessionStorage.setItem('_instance', '{"id":"30", "name":"formation"}');
  });

  await page.goto(`${BASE_URL}/${targetUrl}`, {
    waitUntil: 'networkidle0',
  });

  let action = 'no';
  let outUrl = targetUrl;
  if (queryElements.action) {
    action = queryElements.action;
    let x = queryElements.x | 0;
    let y = queryElements.y | 0;
    const data = await page.evaluate(
      ({ x, y }) => {
        const aTag = document.elementFromPoint(x, y).closest('a');
        const link = null === aTag ? '' : aTag.href;
        return {
          width: document.documentElement.clientWidth,
          height: document.documentElement.clientHeight,
          deviceScaleFactor: window.devicePixelRatio,
          link: link,
        };
      },
      { x, y }
    );

    await page.goto(`${data.link}`, {
      waitUntil: 'networkidle0',
    });

    outUrl = data.link;
  }

  const filename = Math.floor(Date.now() / 1000);
  await page.screenshot({ path: `${filename}.jpeg` });
  await browser.close();

  const image = fs.readFileSync(`${filename}.jpeg`);

  fs.unlinkSync(`${filename}.jpeg`);

  return {
    targetUrl: formatUrl(outUrl),
    image: 'image/jpeg;base64,' + Buffer.from(image).toString('base64'),
  };
});