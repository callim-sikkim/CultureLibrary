import {Component, inject, signal} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {rxResource} from '@angular/core/rxjs-interop';
import {BookService} from './shared/api-book-service';
import {JsonPipe} from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JsonPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('CultureLibrary.Web');
  #bookService = inject(BookService);
  readonly booksResource = rxResource({
    stream: () => this.#bookService.apiBookGet()
  });
}
