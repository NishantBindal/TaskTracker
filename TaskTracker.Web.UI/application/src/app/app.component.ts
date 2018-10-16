import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/core/services/api.service';
import { LoggerService } from 'src/core/services/logger.service';
import { ServiceResultResolverService } from 'src/core/services/resolver.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Task Tracker | Home';
  constructor(
    private apiService: ApiService,
    private logger: LoggerService,
    private resolver: ServiceResultResolverService
  ) {}
  ngOnInit(): void {
    this.Initialize().then(() => {
      return;
    });
  }
  async Initialize() {
    this.logger.Debug(
      this.resolver.Resolve(await this.apiService.TestServiceConnection())
    );
  }
}
