import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import viMessages from 'devextreme/localization/messages/vi.json';

import { loadMessages } from 'devextreme/localization';

if (environment.production) {
  enableProdMode();
}
loadMessages(viMessages);

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
