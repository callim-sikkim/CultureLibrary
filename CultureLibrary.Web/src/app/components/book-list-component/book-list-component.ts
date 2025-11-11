import {Component, inject} from '@angular/core';
import {BookService} from '../../shared/api-book-service';
import {rxResource} from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-book-list-component',
  imports: [],
  templateUrl: './book-list-component.html',
  styleUrl: './book-list-component.scss',
})
export class BookListComponent {
  #bookService = inject(BookService);

  readonly booksResource = rxResource({
    stream: () => this.#bookService.apiBookGet()
  });
}
