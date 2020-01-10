using System;
using Lessons.Enumerator;

namespace Lessons.Builder
{
    public static class Tree
    {
        public static TreeBuilder<TValue> Create<TValue>() => new TreeBuilder<TValue>();
    }
    
    public class TreeBuilder<TValue>
    {
        private TreeBuilderWithValue<TValue> _right;
        private TreeBuilderWithValue<TValue> _left;

        public TreeBuilder<TValue> WithLeft(Func<TreeBuilder<TValue>, TreeBuilderWithValue<TValue>> setup)
        {
            var builder = new TreeBuilder<TValue>();
            _left = setup(builder);
            return this;
        }

        public TreeBuilder<TValue> WithRight(Func<TreeBuilder<TValue>, TreeBuilderWithValue<TValue>> setup)
        {
            var builder = new TreeBuilder<TValue>();
            _right = setup(builder);
            return this;
        }
        
        public TreeBuilder<TValue> WithLeftLeaf(TValue value)
        {
            var builder = new TreeBuilderWithValue<TValue>(null, null, value);
            _left = builder;
            return this;
        }

        public TreeBuilder<TValue> WithRightLeaf(TValue value)
        {
            var builder = new TreeBuilderWithValue<TValue>(null, null, value);
            _right = builder;
            return this;
        }

        public TreeBuilderWithValue<TValue> WithValue(TValue value)
        {
            return new TreeBuilderWithValue<TValue>(_left, _right, value);
        }
    }

    public sealed class TreeBuilderWithValue<TValue>
    {
        private readonly TreeBuilderWithValue<TValue> _left;
        private readonly TreeBuilderWithValue<TValue> _right;
        private readonly TValue _value;

        public TreeBuilderWithValue(
            TreeBuilderWithValue<TValue> left, 
            TreeBuilderWithValue<TValue> right,
            TValue value)
        {
            _left = left;
            _right = right;
            _value = value;
        }

        public Tree<TValue> Build() => new Tree<TValue>(_value, _left?.Build(), _right?.Build());   
    }
}