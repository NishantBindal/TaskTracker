import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import * as moment from 'moment';
import { Sprint } from 'src/core/models/sprint.model';
import { ApiService } from 'src/core/services/api.service';
import { LoggerService } from 'src/core/services/logger.service';
import { ServiceResultResolverService } from 'src/core/services/resolver.service';
import { Messages } from 'src/core/enums/messages.enum';

@Component({
  selector: 'app-sprint',
  templateUrl: './sprint.component.html',
  styleUrls: ['./sprint.component.css']
})
export class SprintComponent implements OnInit {
  constructor(
    private apiService: ApiService,
    private logger: LoggerService,
    private router: Router,
    private route: ActivatedRoute,
    private resolver: ServiceResultResolverService
  ) {}

  boardId: number;
  UpcomingSprints: Sprint[];
  CurrentSprints: Sprint[];
  IncompleteSprints: Sprint[];
  CompleteSprints: Sprint[];
  AllSprints: Sprint[];
  ngOnInit() {
    this.Initialize().then(() => {
      return;
    });
  }

  async Initialize() {
    this.route.params.subscribe(params => (this.boardId = params['id']));
    const result = this.resolver.Resolve(
      await this.apiService.GetSprints(this.boardId)
    );
    switch (result.ResultMessage) {
      case Messages.Success:
        const currentDate = moment().toDate();
        this.AllSprints = result.Result;
        this.logger.Debug(this.AllSprints);
        this.UpcomingSprints = this.AllSprints.filter(
          s => s.StartDate > currentDate
        );
        this.CurrentSprints = this.AllSprints.filter(
          s => s.StartDate < currentDate && s.EndDate > currentDate
        );
        this.IncompleteSprints = this.AllSprints.filter(
          s => !s.IsComplete && s.EndDate < currentDate
        );
        this.CompleteSprints = this.AllSprints.filter(s => s.IsComplete);
        break;
      case Messages.Failed:
        break;
    }
  }

  OpenSprint(id: string) {
    this.router.navigate(['sprints', id]);
  }

  OpenNewSprintWizard() {}
}
