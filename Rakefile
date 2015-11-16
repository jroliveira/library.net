require 'albacore'

build_mode = ENV['CONFIGURATION'] || 'Release'

task :default => [:compile, :test]

desc 'Compile all projects'
build :compile do |b|
  b.sln = 'library.net.sln'
  b.target = ['Clean', 'Rebuild']
  b.prop 'Configuration', build_mode
  b.prop 'VisualStudioVersion', '12.0'
  b.be_quiet
  b.nologo
end

desc 'Restore nuget packages for all projects'
nugets_restore :restore do |p|
  p.out = 'packages'
  p.exe = '.nuget/NuGet.exe'
end