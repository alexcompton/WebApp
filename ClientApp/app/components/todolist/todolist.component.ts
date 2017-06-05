import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'todolist',
    template: require('./todolist.component.html')
})

export class TodoListComponent {
    public items: Item[];
    public http: Http;
    public origninUrl: string;
    public activeTask: Item;
    public activeTitle: string;
    public requestCommand: string;
    public requestType: Request;

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.http = http;
        this.origninUrl = originUrl;
        this.getTable();
    }

    getTable(): void {
        this.http.get(this.origninUrl + '/api/Item').subscribe(result => {
            let items = result.json();
            this.items = items;
        });
    };

    closeActiveItem(): void {
        this.activeTask = null;
    }

    updateRequest(): void {
        this.http.put(this.origninUrl + '/api/Item', this.activeTask).subscribe(result => {
            this.refreshPage();
            // todo: add error handling
        });
    }

    createRequest(): void {
        this.http.post(this.origninUrl + '/api/Item', this.activeTask).subscribe(result => {
            this.refreshPage();
        });
    }

    deleteRequest(): void {
        this.http.delete(this.origninUrl + '/api/Item/' + this.activeTask.id).subscribe(result => {
            // todo: add error handling
            this.refreshPage();
        });
    }

    refreshPage(): void {
        this.closeActiveItem();
        this.items = null;
        this.getTable();
    }

    makeRequest(): void {
        switch (this.requestType) {
            case Request.Create:
                this.createRequest();
                break;
            case Request.Read:
                // we might want to reread the db after cruds...
                break;
            case Request.Update:
                this.updateRequest();
                break;
            case Request.Delete:
                this.deleteRequest();
                break;
            default:
                console.log("this shouldn't ever happen");
        }

        //this.refreshPage();
    }

    newTask(): void {
        this.requestType = Request.Create;
        this.requestCommand = "Create Task";
        this.activeTitle = "Create a New Task";
        this.activeTask = new Task();
    }

    viewTask(item: Item): void {
        this.activeTask = item;
        this.requestType = Request.Update;
        this.requestCommand = "Edit Task";
        this.activeTitle = "Edit Task: " + item.name;
    }

    deleteTask(): void {
        this.requestType = Request.Delete;
        this.makeRequest();
    }
}

interface Item {
    id: string;
    name: string;
    description: string;
    isComplete: boolean;

}

export class Task implements Item{
    id: string;
    name: string;
    description: string;
    isComplete: boolean;

    constructor() {
        this.id = this.generateUUID();
        this.isComplete = false;
        this.name = "";
        this.description = "";
    }

    private generateUUID(): string {

        var d = new Date().getTime();

        if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
            d += performance.now(); //use high-precision timer if available
        }

        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
    }
}

enum Request {
    Create,
    Read,
    Update,
    Delete
}