import {Injectable} from "@angular/core";

@Injectable()
export class AuthProvider {
  getUserId(): string {
    // It's temporary hardcoded user ID. Change in future, after auth module implementation.
    return 'C9888D13-E9DA-454A-86A2-62BEC0302F2D';
  }
}
