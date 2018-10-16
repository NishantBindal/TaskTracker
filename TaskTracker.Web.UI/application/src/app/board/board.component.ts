import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Board } from 'src/core/models/board.model';
import { ApiService } from 'src/core/services/api.service';
import { ServiceResultResolverService } from 'src/core/services/resolver.service';
import { Messages } from 'src/core/enums/messages.enum';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  constructor(
    private apiService: ApiService,
    private router: Router,
    private resolver: ServiceResultResolverService
  ) {}
  Boards: Board[];
  ngOnInit() {
    this.Initialize().then(() => {
      return;
    });
  }

  async Initialize() {
    const result = this.resolver.Resolve(
      await this.apiService.GetBoards('anyGuid')
    );
    switch (result.ResultMessage) {
      case Messages.Success:
        this.Boards = result.Result;
        break;
      case Messages.Failed:
        break;
    }
  }

  OpenBoard(id: string) {
    this.router.navigate(['boards', id, 'sprints']);
  }
}
