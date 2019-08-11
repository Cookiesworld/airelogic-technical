import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { timingSafeEqual } from 'crypto';
import { Bugmodel } from '../model/bugmodel';

@Injectable({
  providedIn: 'root'
})
export class BugService {

  constructor(private http: HttpClient) {  
   }

   public getBugs() {
     return this.http.get("https://localhost:44330/api/bugs"); 
   }
}
