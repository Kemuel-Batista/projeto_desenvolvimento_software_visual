export class CategoriaServico {
  id: number;
  descricao = '';

  constructor(Id: number, Descricao: string)
  {
    this.id = Id;
    this.descricao = Descricao;
  }
}
