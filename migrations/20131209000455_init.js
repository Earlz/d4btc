
exports.up = function(knex, Promise) {
 knex.schema.createTable('config', function (table) {
    table.increments('id');
    table.string('site_name');
    table.timestamps();
    }).then(function () {
      console.log('Config Table Created!');
    }); 
};

exports.down = function(knex, Promise) {
  knex.schema.dropTable('config');
};
