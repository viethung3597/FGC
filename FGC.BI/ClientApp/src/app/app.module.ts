import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DxLoadPanelModule } from 'devextreme-angular/ui/load-panel';
import { DxMenuModule } from 'devextreme-angular/ui/menu';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';
import { DxChartModule } from "devextreme-angular";
import { DxDateBoxModule } from "devextreme-angular";
import { DxTreeListModule , DxDataGridModule } from "devextreme-angular";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/components/nav-menu/nav-menu.component';
import { HttpAuthErrorInterceptor } from './shared/services/http-auth-error.interceptor';
import { ProfileService } from './shared/services/profile.service';
import { HomeComponent } from './home/home.component';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxListModule } from 'devextreme-angular/ui/list';
import { DxButtonModule } from 'devextreme-angular/ui/button';
import { LogoutButtonComponent } from './shared/components/logout-button.component';
import { ChartComponent } from './shared/components/chart/chart.component';
import { DetailComponent } from './detail/detail.component';
import { RouterModule, Routes } from '@angular/router';
import { Router } from '@angular/router'; 

function initApp(profileService: ProfileService): any {
  return () => profileService.getProfile();
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LogoutButtonComponent,
    HomeComponent,
    ChartComponent,
    DetailComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DxMenuModule,
    DxToolbarModule,
    DxLoadPanelModule,
    DxFormModule,
    DxListModule,
    DxButtonModule,
    DxChartModule,
    DxDateBoxModule,
    DxTreeListModule ,
    DxDataGridModule,
    RouterModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpAuthErrorInterceptor,
      multi: true,
    },
    {
      provide: APP_INITIALIZER,
      useFactory: initApp,
      deps: [ProfileService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
