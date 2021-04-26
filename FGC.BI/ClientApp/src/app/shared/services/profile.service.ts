import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProfile } from '../models/user-profile';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  userProfile!: UserProfile;
  constructor(private http: HttpClient) {}

  getProfile(): Promise<UserProfile> {
    return this.http
      .get('/api/profile')
      .toPromise()
      .then((userProfile: any) => (this.userProfile = userProfile));
  }

  hasPermission(permission: string): boolean {
    if (
      !this.userProfile ||
      !this.userProfile.permissions ||
      !this.userProfile.permissions.length
    ) {
      return false;
    }
    return this.userProfile.permissions.indexOf(permission) !== -1;
  }
}
