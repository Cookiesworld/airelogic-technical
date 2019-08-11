import { Component } from '@angular/core';
import { BugService } from './services/bug.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'airelogic-client-app';

  constructor(private bugService: BugService) {
  
  }  
}

