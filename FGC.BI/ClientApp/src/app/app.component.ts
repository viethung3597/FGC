import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import {
  NavigationCancel,
  NavigationEnd,
  NavigationError,
  NavigationStart,
  Router,
} from '@angular/router';
import { navMenuItems } from './nav.config';
import { UserProfile } from './shared/models/user-profile';
import { ProfileService } from './shared/services/profile.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'FGC BI';
  menuItems = navMenuItems;
  loading = false;
  userProfile: UserProfile;
  dashboards: string[] = [];

  constructor(router: Router, profile: ProfileService) {
    this.userProfile = profile.userProfile;
    this.dashboards = ['Overview', 'Purchase Request', 'Purchase Order'];
    router.events.subscribe((event) => {
      switch (true) {
        case event instanceof NavigationStart:
          this.loading = true;
          break;
        case event instanceof NavigationEnd:
          this.loading = false;
          break;
        case event instanceof NavigationCancel:
          this.loading = false;
          break;
        case event instanceof NavigationError:
          this.loading = false;
          break;
        default:
          break;
      }
    });
  }
}
