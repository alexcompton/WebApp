import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'todolist',
    template: require('./todolist.component.html')
})

export class TodoListComponent {
    public items: Item[];
    public http: Http;
    public activeTask: Item;

    constructor(http: Http) {
        this.http = http;
        this.getTable();
    }

    getTable(): void {
        this.http.get('/api/Item').subscribe(result => {
            let items = result.json();
            this.items = items;
        });
    };

    viewDetails(item: Item): void {
        this.activeTask = item;
    }

    updateTask(): void {
        this.http.put('/api/Item', this.activeTask).subscribe(result => {
            // todo: add error handling
        });
    }

    insertTask(): void {
        this.http.post('/api/Item', this.activeTask).subscribe(result => {
            this.items.push(this.activeTask);
        });
    }

    newTask(): void {
        this.activeTask = new Task();
        this.activeTask.id = this.generateUUID();
        this.activeTask.isComplete = false;
    }

    // todo: generate guid in c#
    generateUUID (): string {

        var d = new Date().getTime();
        
        if (typeof performance !== 'undefined' && typeof performance.now === 'function'){
            d += performance.now(); //use high-precision timer if available
        }
        
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
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
}