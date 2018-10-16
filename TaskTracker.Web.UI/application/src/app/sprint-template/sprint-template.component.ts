import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sprint-template',
  templateUrl: './sprint-template.component.html',
  styleUrls: ['./sprint-template.component.css']
})
export class SprintTemplateComponent implements OnInit {
  @Input()
  sprint: any;

  constructor(private router: Router) {}

  ngOnInit() {
    console.log(this.sprint);
  }

  OpenSprint(id: string) {
    this.router.navigate(['sprints', id]);
  }
}
