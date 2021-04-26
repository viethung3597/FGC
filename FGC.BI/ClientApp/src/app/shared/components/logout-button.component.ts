import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-logout-button',
  template: `
    <dx-button
      width="100%"
      stylingMode="text"
      icon="pinleft"
      text="Đăng xuất"
      (onClick)="navigateToLogoutPage()"
    ></dx-button>
  `,
})
export class LogoutButtonComponent {
  constructor() {}
  navigateToLogoutPage() {
    window.location.href = '/account/logout';
  }
}
