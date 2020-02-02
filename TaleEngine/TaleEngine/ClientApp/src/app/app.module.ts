import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NewActivityComponent } from './new-activity/new-activity.component';
import { ManagementActivitiesComponent } from './management/management-activities/management-activities.component';
import { ActivityService } from '../services/activity-service';
import { ActivityTypesService } from '../services/activity-types-service';
import { TimeSlotsService } from '../services/time-slots-service';
import { EventsService } from '../services/event-service';
import { ActivityFilterComponent } from './activity-filter/activity-filter.component';
import { ActivityStatusService } from '../services/activity-status-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NewActivityComponent,
    ManagementActivitiesComponent,
    ActivityFilterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'new-activity', component: NewActivityComponent },
      { path: 'management-activities', component: ManagementActivitiesComponent }
    ])
    ],
    providers: [ActivityService, ActivityTypesService, TimeSlotsService, EventsService, ActivityStatusService],
  bootstrap: [AppComponent]
})
export class AppModule { }
