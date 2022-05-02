import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizationService } from 'src/app/state/auth/authorization-service';

@Injectable({
  providedIn: 'root',
})
export class ActiveGuard implements CanActivate {
  constructor(private authorizationService: AuthorizationService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.authorizationService.isActive()) {
      return true;
    }

    this.router.navigate(['contact']);
    return false;
  }
}
