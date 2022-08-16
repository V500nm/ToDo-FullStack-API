import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from '../models/tasks.model';

@Injectable({
  providedIn: 'root'
})
export class TasksService {

  baseURL='http://localhost:5269/api/Tasks'
  constructor(private http: HttpClient) { }
  //get all tasks
  getAllTasks(): Observable<Task[]>{
    return this.http.get<Task[]>(this.baseURL);
  }
  addTask(tasks:Task):Observable<Task>{
    tasks.id="00000000-0000-0000-0000-000000000000";
    return this.http.post<Task>(this.baseURL,tasks);
  }
  deleteTask(id:string):Observable<Task>{
    return this.http.delete<Task>(this.baseURL + '/' + id);
  }
  updateTask(tasks:Task):Observable<Task>{
    return this.http.put<Task>(this.baseURL + '/' + tasks.id, tasks)
  }
}
