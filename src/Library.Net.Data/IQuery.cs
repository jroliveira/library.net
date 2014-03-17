namespace Library.Net.Data {

    public interface IQuery { }

    public interface IQuery<out TResult> : IQuery {

        TResult GetResult();
    }

    public interface IQuery<out TResult, in TParam> : IQuery {

        TResult GetResult(TParam param);
    }
}
