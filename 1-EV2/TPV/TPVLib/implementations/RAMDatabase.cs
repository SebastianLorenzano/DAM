﻿
using System.Linq;

namespace TPVLib.implementations
{
    public class RAMDatabase : IDatabase
    {
        private Dictionary<long, Product> _products = new();
        private Dictionary<long, TicketHeader> _ticketHeaders = new();
        private Dictionary<long, TicketBody> _ticketBodies = new();
        private long nextGeneratedId = 1;
        private long nextGeneratedTicketId = 1;
        public long AddProduct(Product product)
        {
            if (product == null)
                throw new Exception("The Product doesn't exist. Adding a Product Failed");
            if (product.Name == null)
                throw new Exception("The Product had no Name. Adding a Product Failed");
            long index = nextGeneratedId++;
            product.Id = index;
            _products.Add(index, product);
            return index;
        }

        public long AddTicketHeader(TicketHeader header)
        {
            if (header == null)
                throw new Exception("The Ticket doesn't exist. Adding a Ticket Failed");
            long id = nextGeneratedTicketId++;
            header.TicketId = id;
            _ticketHeaders.Add(header.TicketId, header);
            return id;

        }

        private void CreateTicketBodyWithId(long id)
        {
            if (!_ticketBodies.ContainsKey(id))
                _ticketBodies.Add(id, new TicketBody());
        }

        public void AddTicketLineWithId(long id, TicketLine line)
        {
            if (line == null)
                throw new Exception("The Product doesn't exist. Updating a Product Failed");
            CreateTicketBodyWithId(id);
            var lines = _ticketBodies[id]._lines;
            int index = lines.IndexOf(line);
            if (index >= 0)
                lines[index].Cantidad += line.Cantidad;
            else
                lines.Add(line);
        }

              
        public List<Product> GetProducts(int offset, int limit)
        {
            var result = new List<Product>();
            if (offset < 0 || offset > _products.Count)
                return result;
            limit = Math.Min(limit, _products.Count);
            for (int i = 0; i < limit; i++)
            {
                result.Add(_products[i + offset]);
            }
            return result;
        }

        public Product? GetProductWithID(long id)
        {
            foreach (var product in _products)
            {
                if (product.Key == id)
                    return product.Value.Clone();
            }
            return null;
        }

        public Product? GetProductWithName(string name)
        {
            foreach (var product in _products)
            {
                if (product.Value.Name == name)
                    return product.Value.Clone();
            }
            return null;
        }

        public Ticket? GetTicketWithID(long id)
        {
            Ticket result;
            
        }


        public bool RemoveProductWithID(long id)
        {
            if (!_products.Remove(id))
                throw new Exception("The Product doesn't exist. Removing a Product Failed");
            return true;
        }



        public void UpdateProductWithID(long id, Product product)
        {       
            if (product != null && _products.ContainsKey(id))
            {
                product.Id = id;
                _products[id] = product;
            }
            else
                throw new Exception("The Product doesn't exist. Updating a Product Failed");
        }





        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }


        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        long IDatabase.AddTicketBodyWithId(long id, TicketBody body)
        {
            throw new NotImplementedException();
        }

        long IDatabase.AddTicketLineWithId(long id, TicketLine line)
        {
            throw new NotImplementedException();
        }
    }
}
