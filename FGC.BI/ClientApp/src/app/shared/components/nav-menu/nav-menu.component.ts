import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { navMenuItems } from 'src/app/nav.config';
import { ProfileService } from 'src/app/shared/services/profile.service';
import { NavMenuItem } from '../../models/nav-menu-item';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent implements OnInit {
  @Input()
  menuItems: NavMenuItem[] = [];

  constructor(private profile: ProfileService, private router: Router) {}

  ngOnInit(): void {
    // console.log(this.menuItems);
  }

  onMenuItemClick(e: any): void {
    if (e.itemData.path) {
      if (e.event.ctrlKey) {
        const url = this.router.serializeUrl(
          this.router.createUrlTree([e.itemData.path])
        );
        window.open(url, '_blank');
      } else {
        this.router.navigateByUrl(e.itemData.path);
      }
    }
  }
}
