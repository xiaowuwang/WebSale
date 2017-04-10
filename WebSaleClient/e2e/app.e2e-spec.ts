import { WebSaleClientPage } from './app.po';

describe('web-sale-client App', function() {
  let page: WebSaleClientPage;

  beforeEach(() => {
    page = new WebSaleClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
