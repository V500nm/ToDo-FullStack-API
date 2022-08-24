import { Component, OnInit } from '@angular/core';
import { TasksService } from './service/tasks.service';
import { Task } from './models/tasks.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'FStoDo';
  updateButton=false;
  toDo: Task[]=[];
  tasks:Task={
    id:'',
    topic:'',
    description:''
  }

  constructor(private tasksService:TasksService){
    
 }
  ngOnInit(): void {
    // this.getAllTasks();
    this.tasksService.getAllTasks()
    .subscribe( Response=>{
      this.toDo = Response;
      
      }
    )
  }
  getAllTasks(){
    this.tasksService.getAllTasks()
    .subscribe( Response=>{
      this.toDo = Response;
      
      }
    )
  }
  onSubmit(){
    if(this.tasks.id===''){
      this.tasksService.addTask(this.tasks)
      .subscribe(
        Response=>{
          this.getAllTasks();
          this.tasks={
            id:'',
            topic:'',
            description:''
          }
        }
      )
    }else{
      this.updateTask(this.tasks)
    }
  }
  deleteTask(id:string){
    this.tasksService.deleteTask(id)
    .subscribe(
      Response=>{
        this.getAllTasks();
      }
    )
  }
  recoverTask(tasks:Task){
    this.updateButton=true;
    this.tasks=tasks;
  }
  updateTask(tasks:Task){
    this.tasksService.updateTask(tasks)
    .subscribe(
      Response=>{
        this.getAllTasks();
        this.tasks={
          id:'',
          topic:'',
          description:''
        }
        this.updateButton=false;
      }
    )
  }
}