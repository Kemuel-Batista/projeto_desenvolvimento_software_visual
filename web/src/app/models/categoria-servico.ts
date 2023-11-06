export class CategoriaServico {
  Id: number;
  Descricao = '';

  constructor(id: number, descricao: string)
  {
    this.Id = id;
    this.Descricao = descricao;
  }
}
