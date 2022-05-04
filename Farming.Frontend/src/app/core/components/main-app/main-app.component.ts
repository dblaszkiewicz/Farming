import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { delay, filter } from 'rxjs/operators';
import { NavigationEnd, Router } from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { TranslateService } from '@ngx-translate/core';
import StoreConnectedComponent from 'src/app/modules/utilities/store-connected.component';
import { ApplicationState } from 'src/app/state';
import { Store } from '@ngrx/store';
import { AuthState } from 'src/app/state/auth/auth.reducer';
import { AuthorizationService } from 'src/app/state/auth/authorization-service';
import { AuthActions } from 'src/app/state/auth/auth.actions';

@UntilDestroy()
@Component({
  selector: 'app-main-app',
  templateUrl: './main-app.component.html',
  styleUrls: ['./main-app.component.scss'],
})
export class MainAppComponent extends StoreConnectedComponent<ApplicationState> implements OnInit, AfterViewInit {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;

  public destkopMode: boolean;

  public isAuthorized: boolean = false;
  public isActive: boolean = false;
  public isAdmin: boolean = false;
  public userName: string;

  constructor(
    public authorizationService: AuthorizationService,
    private observer: BreakpointObserver,
    private router: Router,
    private auth: AuthorizationService,
    store: Store<{ auth: AuthState }>,
    translate: TranslateService
  ) {
    super(store);
  }

  ngOnInit(): void {
    this.authorizationService.isAuthorized$().subscribe(authorized => {
      this.isAuthorized = authorized;
      if (this.isAuthorized) {
        this.userName = this.authorizationService.currentUserName();
      }
    });

    this.authorizationService.isActive$().subscribe(active => {
      this.isActive = active;
    });

    this.authorizationService.isAdmin$().subscribe(admin => {
      this.isAdmin = admin;
    });
  }

  ngAfterViewInit() {
    this.observer
      .observe(['(max-width: 850px)'])
      .pipe(delay(1), untilDestroyed(this))
      .subscribe(res => {
        if (res.matches) {
          this.destkopMode = false;
          this.sidenav.mode = 'over';
          this.sidenav.close();
        } else {
          this.destkopMode = true;
          this.sidenav.mode = 'side';
          this.sidenav.open();
        }
      });

    this.router.events
      .pipe(
        untilDestroyed(this),
        filter(e => e instanceof NavigationEnd)
      )
      .subscribe(() => {
        if (this.sidenav.mode === 'over') {
          this.sidenav.close();
        }
      });
  }

  public logout(): void {
    this.store$.dispatch(AuthActions.logout());
  }
}
