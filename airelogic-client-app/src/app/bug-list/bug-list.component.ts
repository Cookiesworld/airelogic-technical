import { Component, OnInit } from '@angular/core';
import { BugService } from '../services/bug.service';
import { Bugmodel } from '../model/bugmodel';

@Component({
  selector: 'app-bug-list',
  templateUrl: './bug-list.component.html',
  styleUrls: ['./bug-list.component.sass']
})
export class BugListComponent implements OnInit {
  bugs;

  constructor(private bugService: BugService) { 
    this.bugService.getBugs().subscribe((bugsList) =>{
      this.bugs = bugsList;
    })
  }

  ngOnInit() {
  }
}
